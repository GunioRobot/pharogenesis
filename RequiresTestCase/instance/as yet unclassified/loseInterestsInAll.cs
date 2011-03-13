loseInterestsInAll
	^self createdClassesAndTraits 
		, TraitsResource current createdClassesAndTraits 
			do: [:e | self loseInterestsFor: e]