extraSpacePerMorph

	| spaceFillingMorphs spaceNeeded extra |
	spaceFillingMorphs _ 0.
	spaceNeeded _ 2 * (inset + borderWidth).
	orientation = #horizontal ifTrue: [
		submorphs do: [:m |
			spaceNeeded _ spaceNeeded + (m minWidth max: minCellSize).
			(m isLayoutMorph and: [m hResizing = #spaceFill])
				ifTrue: [spaceFillingMorphs _ spaceFillingMorphs + 1]].
		extra _ (bounds width - spaceNeeded) max: 0.
	] ifFalse: [
		submorphs do: [:m |
			spaceNeeded _ spaceNeeded + (m minHeight max: minCellSize).
			(m isLayoutMorph and: [m vResizing = #spaceFill])
				ifTrue: [spaceFillingMorphs _ spaceFillingMorphs + 1]].
		extra _ (bounds height - spaceNeeded) max: 0].

	(submorphs size <= 1 or: [spaceFillingMorphs <= 1]) ifTrue: [^ extra].
	^ extra // spaceFillingMorphs
