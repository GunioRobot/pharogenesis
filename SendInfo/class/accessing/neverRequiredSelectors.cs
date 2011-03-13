neverRequiredSelectors
	| nrs |
	nrs _ Array new: 5.
	nrs at: 1 put: CompiledMethod conflictMarker.
	nrs at: 2 put: CompiledMethod disabledMarker.
	nrs at: 3 put: CompiledMethod explicitRequirementMarker.
	nrs at: 4 put: CompiledMethod implicitRequirementMarker.
	nrs at: 5 put: CompiledMethod subclassResponsibilityMarker.
	^ nrs.
