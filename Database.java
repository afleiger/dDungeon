import java.sql.Statement;

public class Database {

	public void connect(){	
		Class.forName("org.sqlite.JDBC");

		Connection connection = null;
		try
		{
			// create a database connection
			connection = DriverManager.getConnection("jdbc:sqlite:sample.db"); //sample.db is the name of the database
			Statement statement = connection.createStatement();

			statement.executeUpdate("CREATE TABLE HeroStats (name TEXT, maxhp INTEGER, power INTEGER, defense INTEGER, speed INTEGER)");
			statement.executeUpdate("CREATE TABLE MonsterStats (name TEXT, maxhp INTEGER, power INTEGER, defense INTEGER, speed INTEGER)");
			statement.executeUpdate("INSERT INTO HeroStats values('Warrior', 100, 10, 10, 5)");
			
			ResultSet rs = statement.executeQuery("SELECT * FROM HeroStats");
			while(rs.next())
			{
				// read the result set
				System.out.println("name = " + rs.getString("name"));
				System.out.println("maxHp = " + rs.getInt("maxHp"));
				System.out.println("power = " + rs.getInt("power"));
				System.out.println("defense = " + rs.getInt("defense"));
				System.out.println("speed = " + rs.getInt("speed"));
			}
		}
		catch(SQLException e)
		{
			// if the error message is "out of memory", 
			// it probably means no database file is found
			System.err.println(e.getMessage());
		}
		finally
		{
			try
			{
				if(connection != null)
					connection.close();
			}
			catch(SQLException e)
			{
				// connection close failed.
				System.err.println(e);
			}
		}
	}
}