repairEmbeddedWorlds

	| transform eWorld toDoList |

	toDoList _ OrderedCollection new.
	self allMorphsDo: [ :each |
		(each isKindOf: EmbeddedWorldBorderMorph) ifTrue: [
			transform _ each submorphs at: 1 ifAbsent: [nil].
			transform ifNotNil: [
				eWorld _ transform submorphs at: 1 ifAbsent: [nil].
				eWorld ifNotNil: [
					toDoList add: {transform. eWorld}.
				].
			].
			"Smalltalk at: #Q put: {self. each. transform. eWorld}."
		].
	].
	toDoList do: [ :each |
		each first addMorph: each second.
	].