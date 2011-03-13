storeCodeOn: aStream indent: tabCount

	| phrase player costume |
	phrase _ self outermostMorphThat: [:m| m isKindOf: PhraseTileMorph].
	phrase ifNil: [^ self basicStoreCodeOn: aStream indent: tabCount].

	player _ phrase associatedPlayer.
	player ifNil: [^ self basicStoreCodeOn: aStream indent: tabCount].

	costume _ player costume.
	costume ifNil: [^ self basicStoreCodeOn: aStream indent: tabCount].

	(player isKindOf: KedamaExamplerPlayer) ifTrue: [
		^ self kedamaStoreCodeOn: aStream indent: tabCount actualObject: player costume renderedMorph kedamaWorld].

	(costume renderedMorph isMemberOf: KedamaMorph) ifTrue: [
		^ self kedamaStoreCodeOn: aStream indent: tabCount actualObject: costume renderedMorph].

	^ self basicStoreCodeOn: aStream indent: tabCount.