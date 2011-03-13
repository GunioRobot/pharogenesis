canTranslateFrom

	Languages ifNil: [Languages _ #(English Portuguese).
		CanTranslateFrom _ #(French German Spanish English Portuguese 
			Italian Norwegian)].		"see www.freetranslation.com/"
	^ CanTranslateFrom 