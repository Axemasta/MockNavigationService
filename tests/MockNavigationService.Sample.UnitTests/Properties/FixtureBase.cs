namespace MockNavigationService.Sample.UnitTests.Properties;

public abstract class FixtureBase<TSut>
{
	private Lazy<TSut> sut;

	protected TSut Sut => sut.Value;

	public FixtureBase()
	{
		sut = new Lazy<TSut>(CreateSystemUnderTest, LazyThreadSafetyMode.ExecutionAndPublication);
	}

	protected abstract TSut CreateSystemUnderTest();
}

