testCharacterChanging
	| testString item shouldBe resultingString where |
	#(';' '^' '!' '<' '/' '(' )
		do: [:c | #('*' '* ' '*  ' '**' '** ' '**  ' 
			')' '*)' '* )' '*  )' '**)' '** )' '**  )' 
			')' '*)' '*X)' '*XX)' '**)' '**X)' '**XX)' 
			'))' '*))' '*X))' '*XX))' '**))' '**X))' '**XX))' 
			'(' '*(' '*X(' '*XX(' '**)' '**X(' '**XX(' 
			'((' '*((' '*X((' '*XX((' '**((' '**X((' '**XX((' 
						 )
				do: [:template | 
					testString := template copyReplaceAll: '*' with: c.
					testString
						permutationsDo: [:mixedUp | 
							item := mixedUp copy.
							shouldBe := self calculateShouldBeFrom: item using: c.
							resultingString := self modifySqueakMenu: item copy.
							self should: [shouldBe = resultingString].
							(where := resultingString indexOf: $/) > 0
								ifTrue: [self should: [(mixedUp at: where) = $(].
										self should: [(mixedUp at: where+2) = $)].
										self should: [(mixedUp at: where+1) asUppercase = (resultingString at: where+1)]]]]]