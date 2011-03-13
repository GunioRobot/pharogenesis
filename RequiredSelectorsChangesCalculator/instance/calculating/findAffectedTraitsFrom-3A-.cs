findAffectedTraitsFrom: targetTraitsCollection
	traitsToUpdate := targetTraitsCollection 
				select: [:t | modifiedBehaviors anySatisfy: [:mb | t traitCompositionIncludes: mb]]