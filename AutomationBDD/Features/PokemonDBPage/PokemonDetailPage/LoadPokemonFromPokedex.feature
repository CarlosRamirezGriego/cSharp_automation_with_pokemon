Feature: Test for Loading Pokemon From Pokedex Page

@mytag
Scenario Outline: The user should be able to load the detail page from all the Pokemon from the Pokedex Page
	Given that the test user has loaded the PokemonDB Page
	And that the test user has navigated to the National Pokedex page using the Quicklink
	When the test user clicks over the '<pokemon>' from the list
	Then the test user should be redirected to the '<pokemon>' Pokemon detail page

	Examples:
	| pokemon |
	| Pikachu |
	| Mewtwo  |