Feature: Tests for the PokemonAPI GET "api/v2/pokemon/" endpoint

@mytag
Scenario: User should be able to get Information from valid Pokemon Names
	Given that the test user selects the '<pokemon>' Pokemon to retrieve information
	When the test user queries the API with the test Pokemon name
	Then the user should '<flag>' receive information

	Examples: 
	| pokemon  | flag  |
	| Mewtwo   | true  |
	| Pikachu  | true  |
	| Piikachu | false |

