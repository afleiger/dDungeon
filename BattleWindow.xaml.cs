using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ChrisistheonGUI
{
    /// <summary>
    /// Interaction logic for BattleWindow.xaml
    /// </summary>
    public partial class BattleWindow : Window
    {
        private MainWindow mainWin;
        private bool IsBattleConcluded;
        private Party heroParty;
        private MonsterParty monsterParty;
        private List<A_Entity> BattleOrder;

        private bool monster1Exists;
        private bool monster2Exists;
        private bool monster3Exists;

        private bool player2Exists;
        private bool player3Exists;

        private A_Hero player1;
        private A_Hero player2;
        private A_Hero player3;

        private A_Monster monster1;
        private A_Monster monster2;
        private A_Monster monster3;

        private Party availableHeroTargets;
        private MonsterParty availableMonsterTargets;

        private A_Ability selectedAbility;
        private List<A_Entity> selectedTargs;
        private int targNum;

        private int tNum;

        private int remainingMonsters;

        public BattleWindow(MainWindow mainWin, bool isBoss)
        {
            InitializeComponent();
            this.mainWin = mainWin;
            this.IsBattleConcluded = false;

            heroParty = mainWin.playerParty;
            availableHeroTargets = new Party();
            availableHeroTargets.addMember(mainWin.playerParty.player1);
            availableHeroTargets.addMember(mainWin.playerParty.player2);
            availableHeroTargets.addMember(mainWin.playerParty.player3);
            
            player1 = heroParty.player1;
            player2 = heroParty.player2;
            player3 = heroParty.player3;
            selectedTargs = new List<A_Entity>();

            monster1Exists = false;
            monster2Exists = false;
            monster3Exists = false;

            player2Exists = true;
            player3Exists = true;

            if(isBoss)
            {
                monsterParty = new MonsterParty(MonsterFactory.randomBoss());
            }
            else
            {
                monsterParty = new MonsterParty(MonsterFactory.randomMonsters());
            }
            availableMonsterTargets = new MonsterParty();
            foreach(A_Monster cur in monsterParty.mList)
            {
                availableMonsterTargets.mList.Add(cur);
            }
            remainingMonsters = monsterParty.Size;

            setUpMonsters();

            UpdateAllFields();
            CombatLog.Text = "**THE BATTLE COMMENCES**\n";

            BattleOrder = CreateBattleOrderList();

            continueButton.IsEnabled = true;
        }

        private void continueButton_Click(object sender, RoutedEventArgs e)
        {
            continueButton.IsEnabled = false;
            while(BattleOrder[tNum].IsDead)
            {
                tNum++;
                tNum = tNum % BattleOrder.Count;
            }
            TurnTime(BattleOrder[tNum]);
            LightUpdate();
        }

        private void TurnTime(A_Entity ent)
        {
            if(ent.IsPlayer)
            {
                CombatLog.Text += "\n**Your Turn - Pick An Ability**";
                PlayerTurn();
                if (BattleOrder[tNum].Status == "Stealthed")
                {
                    BattleOrder[tNum].Status = "Normal";
                }

                if (BattleOrder[tNum].Status == "Stealthing")
                {
                    BattleOrder[tNum].Status = "Stealthed";
                }
            }
            else
            {

                if (BattleOrder[tNum].Status == "Stealthing")
                {
                    BattleOrder[tNum].Status = "Stealthed";
                }
                ComputerTurn();
                if (BattleOrder[tNum].Status == "Stealthed")
                {
                    BattleOrder[tNum].Status = "Normal";
                }
            }

            tNum++;
            tNum = tNum % BattleOrder.Count;
        }

        private void PlayerTurn()
        {
            if(player1.spellSlots >= player1.AbilityList[0].slotsRequired)
            {
                AbilityButton1.IsEnabled = true;
            }
            if(player1.AbilityList.Count > 1)
            {
                if (player1.spellSlots >= player1.AbilityList[1].slotsRequired)
                {
                    AbilityButton2.IsEnabled = true;
                }
            }
            if(player1.AbilityList.Count > 2)
            {
                if (player1.spellSlots >= player1.AbilityList[2].slotsRequired)
                {
                    AbilityButton3.IsEnabled = true;
                }
            }
            if(player1.AbilityList.Count > 3)
            {
                if (player1.spellSlots >= player1.AbilityList[3].slotsRequired)
                {
                    AbilityButton4.IsEnabled = true;
                }
            }
        }

        private void ComputerTurn()
        {
            CombatLog.Text += BattleOrder[tNum].TakeTurn(availableHeroTargets, availableMonsterTargets);
            this.CombatScroller.ScrollToBottom();
            continueButton.IsEnabled = true;
        }

        private void setUpMonsters()
        {
            if(remainingMonsters > 0)
            {
                monster1 = monsterParty.monster1;
                monster1Exists = true;
            }
            if (remainingMonsters > 1)
            {
                monster2 = monsterParty.monster2;
                monster2Exists = true;
            }

            if (remainingMonsters > 2)
            {
                monster3 = monsterParty.monster3;
                monster3Exists = true;
            }
        }

        private List<A_Entity> CreateBattleOrderList()
        {
            List<A_Entity> ret = new List<A_Entity>();

            if(!player1.IsDead)
                ret.Add(player1);

            if(!player2.IsDead)
                ret.Add(player2);

            if(!player3.IsDead)
                ret.Add(player3);

            if(remainingMonsters >= 1)
                ret.Add(monster1);

            if (remainingMonsters >= 2)
                ret.Add(monster2);

            if (remainingMonsters >= 3)
                ret.Add(monster3);

            ret.Sort();
            return ret;
        }

        private void LightUpdate()
        {

            player1Box.Header = "Status: " + player1.Status;
            player2Box.Header = "Status: " + player2.Status;
            player3Box.Header = "Status: " + player3.Status;

            barCharacter1.Value = heroParty.playerHealthPercent;
            barCharacter2.Value = heroParty.member1HealthPercent;
            barCharacter3.Value = heroParty.member2HealthPercent;

            player1HealthNums.Content = ((int)player1.health) + " / " + player1.maxHealth;
            player2HealthNums.Content = ((int)player2.health) + " / " + player2.maxHealth;
            player3HealthNums.Content = ((int)player3.health) + " / " + player3.maxHealth;

            player1Slots.Content = "SpellSlots: " + player1.spellSlots;
            player2Slots.Content = "SpellSlots: " + player2.spellSlots;
            player3Slots.Content = "SpellSlots: " + player3.spellSlots;

            UpdateAllMonsterFieldsLight(monsterParty.Size);

            if(monster1Exists)
            {
                if (monster1.IsDead && !monster1.HasDied)
                {
                    monster1Exists = false;
                    monster1.HasDied = true;
                    availableMonsterTargets.mList.Remove(monster1);
                    monster1Box.IsEnabled = false;
                    monster1.Status = "Dead";
                    CombatLog.Text += "\n**" + monster1.charString + " is dead.**";
                    remainingMonsters--;
                }
            }
            if(monster2Exists)
            {
                if (monster2.IsDead && !monster2.HasDied)
                {
                    monster2Exists = false;
                    monster2.HasDied = true;
                    availableMonsterTargets.mList.Remove(monster2);
                    monster2Box.IsEnabled = false;
                    monster2.Status = "Dead";
                    CombatLog.Text += "\n**" + monster2.charString + " is dead.**";
                    remainingMonsters--;
                }
            }
            if(monster3Exists)
            {
                if (monster3.IsDead && !monster3.HasDied)
                {
                    monster3Exists = false;
                    monster3.HasDied = true;
                    availableMonsterTargets.mList.Remove(monster3);
                    monster3Box.IsEnabled = false;
                    monster3.Status = "Dead";
                    CombatLog.Text += "\n**" + monster3.charString + " is dead.**";
                    remainingMonsters--;
                }
            }

            if(player1.IsDead)
            {
                mainWin.GameOver();
            }
            if(player2.IsDead && !player2.HasDied)
            {
                player2.HasDied = true;
                availableHeroTargets.mList.Remove(player2);
                player2Box.IsEnabled = false;
                player2.Status = "Unconscious";
                CombatLog.Text += "\n**" + player2.charString + " has fallen unconscious.**";
            }
            if (player3.IsDead && !player3.HasDied)
            {
                player3.HasDied = true;
                availableHeroTargets.mList.Remove(player3);
                player3Box.IsEnabled = false;
                player3.Status = "Unconscious";
                CombatLog.Text += "\n**" + player3.charString + " has fallen unconscious.**";
            }

            if(remainingMonsters <= 0)
            {
                CombatVictory();
            }
        }

        private void CombatVictory()
        {
            CombatLog.Text += "\n\n**You are Victorious!**";

            continueButton.IsEnabled = false;

            leaveCombat.Visibility = Visibility.Visible;
            leaveCombat.IsEnabled = true;
        }
        private void UpdateAllFields()
        {
            player1Box.Header = "Status: " + player1.Status;
            player2Box.Header = "Status: " + player2.Status;
            player3Box.Header = "Status: " + player3.Status;

            barCharacter1.Value = heroParty.playerHealthPercent;
            barCharacter2.Value = heroParty.member1HealthPercent;
            barCharacter3.Value = heroParty.member2HealthPercent;

            player1HealthNums.Content = ((int)player1.health) + " / " + player1.maxHealth;
            player2HealthNums.Content = ((int)player2.health) + " / " + player2.maxHealth;
            player3HealthNums.Content = ((int)player3.health) + " / " + player3.maxHealth;

            player1Slots.Content = "SpellSlots: " + player1.spellSlots;
            player2Slots.Content = "SpellSlots: " + player2.spellSlots;
            player3Slots.Content = "SpellSlots: " + player3.spellSlots;

            buttonChar1.Content = player1.charString;
            buttonChar2.Content = player2.charString;
            buttonChar3.Content = player3.charString;

            buttonChar1.ToolTip = player1.toolTip;
            buttonChar2.ToolTip = player2.toolTip;
            buttonChar3.ToolTip = player3.toolTip;

            SetAbilityButtons(player1.NumberOfAbilities);
            UpdateAllMonsterFields(monsterParty.Size);

        }

        private void UpdateAllMonsterFields(int x)
        {
            if(x >= 1)
            {
                monster1 = monsterParty.monster1;
                buttonMon1.Visibility = Visibility.Visible;
                monster1Box.Visibility = Visibility.Visible;
                monster1Box.Header = "Status: " + monster1.Status;
                barMonster1.Value = monsterParty.member1HealthPercent;
                monster1HealthNums.Content = ((int)monster1.health) + " / " + ((int)monster1.maxHealth);
                buttonMon1.Content = monster1.charString;
                buttonMon1.ToolTip = monster1.toolTip;
            }
            if(x >= 2)
            {
                monster2 = monsterParty.monster2;
                buttonMon2.Visibility = Visibility.Visible;
                monster2Box.Visibility = Visibility.Visible;
                monster2Box.Header = "Status: " + monster2.Status;
                barMonster2.Value = monsterParty.member2HealthPercent;
                monster2HealthNums.Content = ((int)monster2.health) + " / " + ((int)monster2.maxHealth);
                buttonMon2.Content = monster2.charString;
                buttonMon2.ToolTip = monster2.toolTip;
            }
            if(x >= 3)
            {
                monster3 = monsterParty.monster3;
                buttonMon3.Visibility = Visibility.Visible;
                monster3Box.Visibility = Visibility.Visible;
                monster3Box.Header = "Status: " + monster3.Status;
                barMonster3.Value = monsterParty.member3HealthPercent;
                monster3HealthNums.Content = ((int)monster3.health) + " / " + ((int)monster3.maxHealth);
                buttonMon3.Content = monster3.charString;
                buttonMon3.ToolTip = monster3.toolTip;
            }
        }

        private void UpdateAllMonsterFieldsLight(int x)
        {
            if (x >= 1)
            {
                monster1Box.Header = "Status: " + monster1.Status;
                barMonster1.Value = monsterParty.member1HealthPercent;
                monster1HealthNums.Content = ((int)monster1.health) + " / " + ((int)monster1.maxHealth);
            }
            if (x >= 2)
            {
                monster2Box.Header = "Status: " + monster2.Status;
                barMonster2.Value = monsterParty.member2HealthPercent;
                monster2HealthNums.Content = ((int)monster2.health) + " / " + ((int)monster2.maxHealth);
            }
            if (x >= 3)
            {
                monster3Box.Header = "Status: " + monster3.Status;
                barMonster3.Value = monsterParty.member3HealthPercent;
                monster3HealthNums.Content = ((int)monster3.health) + " / " + ((int)monster3.maxHealth);
            }
        }

        private void SetAbilityButtons(int x)
        {
            if(x >= 1)
            {
                AbilityButton1.Visibility = Visibility.Visible;
                AbilityButton1.Content = player1.AbilityList[0].Name;
                AbilityButton1.ToolTip = player1.AbilityList[0].Description;
            }
            if(x >= 2)
            {
                AbilityButton2.Visibility = Visibility.Visible;
                AbilityButton2.Content = player1.AbilityList[1].Name;
                AbilityButton2.ToolTip = player1.AbilityList[1].Description;
            }
            if (x >= 3)
            {
                AbilityButton3.Visibility = Visibility.Visible;
                AbilityButton3.Content = player1.AbilityList[2].Name;
                AbilityButton3.ToolTip = player1.AbilityList[2].Description;
            }
            if (x >= 4)
            {
                AbilityButton4.Visibility = Visibility.Visible;
                AbilityButton4.Content = player1.AbilityList[3].Name;
                AbilityButton4.ToolTip = player1.AbilityList[3].Description;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IsBattleConcluded = true;
            this.mainWin.IsEnabled = true;
            this.mainWin.Focus();
            if(player2.Status == "Unconscious")
            {
                player2.HasDied = false;
                player2.Status = "Normal";
                if(player2.IsDead)
                    player2.health = 1;
            }
            if (player3.Status == "Unconscious")
            {
                player3.HasDied = false;
                player3.Status = "Normal";
                if(player3.IsDead)
                    player3.health = 1;
            }
            heroParty.setStatsToDefault();
            mainWin.UpdateInfo();
            this.Close();
        }

        protected override void OnClosed(EventArgs e)
        {
            if(!IsBattleConcluded)
            {
                Application.Current.Shutdown();
            }
            else
            {
                this.mainWin.IsEnabled = true;
                this.mainWin.Focus();
            }
        }

        private void SetAbilityButtons(bool inc)
        {
            AbilityButton1.IsEnabled = inc;
            AbilityButton2.IsEnabled = inc;
            AbilityButton3.IsEnabled = inc;
            AbilityButton4.IsEnabled = inc;
        }

        private void SetTargetButtons(bool inc)
        {
            buttonChar1.IsEnabled = inc;
            if(player2Exists)
            {
                buttonChar2.IsEnabled = inc;
            }
            if(player3Exists)
            {
                buttonChar3.IsEnabled = inc;
            }
            if(monster1Exists)
            {
                buttonMon1.IsEnabled = inc;
            }
            if(monster2Exists)
            {
                buttonMon2.IsEnabled = inc;
            }
            if(monster3Exists)
            {
                buttonMon3.IsEnabled = inc;
            }
            cancelButton.IsEnabled = inc;
        }

        private void buttonMon1_Click(object sender, RoutedEventArgs e)
        {
            selectedTargs.Add(monster1);
            targNum--;
            SelectTargets();
        }

        private void buttonMon2_Click(object sender, RoutedEventArgs e)
        {
            selectedTargs.Add(monster2);
            targNum--;
            SelectTargets();
        }

        private void buttonMon3_Click(object sender, RoutedEventArgs e)
        {
            selectedTargs.Add(monster3);
            targNum--;
            SelectTargets();
        }

        private void buttonChar1_Click(object sender, RoutedEventArgs e)
        {
            selectedTargs.Add(player1);
            targNum--;
            SelectTargets();
        }

        private void buttonChar2_Click(object sender, RoutedEventArgs e)
        {
            selectedTargs.Add(player2);
            targNum--;
            SelectTargets();
        }

        private void buttonChar3_Click(object sender, RoutedEventArgs e)
        {
            selectedTargs.Add(player3);
            targNum--;
            SelectTargets();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            selectedTargs.Clear();
            SetTargetButtons(false);
            cancelButton.IsEnabled = false;
            PlayerTurn();
        }

        private void SelectTargets()
        {
            SetAbilityButtons(false);
            if(targNum > 0)
            {
                SetTargetButtons(true);
                CombatLog.Text += "\n**Select A Target**";
            }
            else if(targNum == -1)//Ability is AoE on Enemies
            {
                
                foreach (A_Entity cur in availableMonsterTargets.mList)
                {
                    selectedTargs.Add(cur);
                }

                CombatLog.Text += selectedAbility.use(player1, selectedTargs);
                this.CombatScroller.ScrollToBottom();
                selectedTargs.Clear();
                SetTargetButtons(false);
                continueButton.IsEnabled = true;
                removeStealth();
                LightUpdate();
            }
            else if (targNum == -2) //Ability is AoE on Allies
            {
                foreach (A_Entity cur in availableHeroTargets.mList)
                {
                    selectedTargs.Add(cur);
                }

                CombatLog.Text += selectedAbility.use(player1, selectedTargs);
                this.CombatScroller.ScrollToBottom();
                selectedTargs.Clear();
                SetTargetButtons(false);
                continueButton.IsEnabled = true;
                removeStealth();
                LightUpdate();
            }

            else
            {
                CombatLog.Text += selectedAbility.use(player1, selectedTargs);
                this.CombatScroller.ScrollToBottom();
                selectedTargs.Clear();
                SetTargetButtons(false);
                continueButton.IsEnabled = true;
                removeStealth();
                LightUpdate();
            }
        }

        private void AbilityButton1_Click(object sender, RoutedEventArgs e)
        {
            selectedAbility = player1.AbilityList[0];
            targNum = selectedAbility.Targets;
            SelectTargets();
        }

        private void AbilityButton2_Click(object sender, RoutedEventArgs e)
        {
            selectedAbility = player1.AbilityList[1];
            targNum = selectedAbility.Targets;
            SelectTargets();
        }

        private void AbilityButton3_Click(object sender, RoutedEventArgs e)
        {
            selectedAbility = player1.AbilityList[2];
            targNum = selectedAbility.Targets;
            SelectTargets();
        }

        private void AbilityButton4_Click(object sender, RoutedEventArgs e)
        {
            selectedAbility = player1.AbilityList[3];
            targNum = selectedAbility.Targets;
            SelectTargets();
        }

        private void removeStealth()
        {
            if(player1.Status == "Stealthed")
            {
                player1.Status = "Normal";
            }

            if(player2Exists)
            {
                if(player2.Status == "Stealthed")
                {
                    player2.Status = "Normal";
                }
            }
            if(player3Exists)
            {
                if (player3.Status == "Stealthed")
                {
                    player3.Status = "Normal";
                }
            }
            if(monster1Exists)
            {
                if (monster1.Status == "Stealthed")
                {
                    monster1.Status = "Normal";
                }
            }
            if(monster2Exists)
            {
                if (monster2.Status == "Stealthed")
                {
                    monster2.Status = "Normal";
                }
            }
            if(monster3Exists)
            {
                if (monster3.Status == "Stealthed")
                {
                    monster3.Status = "Normal";
                }
            }
        }
    }
}
