noteInterestsForAll
	self createdClassesAndTraits 
		, TraitsResource current createdClassesAndTraits 
			do: [:e | self noteInterestsFor: e]