using PgmTest;

string resourcesPath = Path.Combine(AppContext.BaseDirectory, "resources");
string filePath = Path.Combine(resourcesPath, "Test");
var checker = new CapturesChecker(filePath);
checker.Check();