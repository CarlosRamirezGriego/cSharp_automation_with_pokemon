Feature: Tests for the PokemonEVManagement Class

@mytag
Scenario Outline: Adding EVs to the HP Stat
	Given that the user has generated an EV Management Object
	And that the test user has allocated '<initialValue>' HP points already
	When the test user adds '<secondValue>' more points to the HP
	Then the HP allocated points should be '<expected>'

	Examples:
	| initialValue | secondValue | expected |
	| 200          | 253         | 200      |
	| 200          | 52          | 252      |
	| 100          | 52          | 152      |
	| 254          | 0           | 0        |
	| 254          | 1           | 1        |
	| -1           | -1          | 0        |