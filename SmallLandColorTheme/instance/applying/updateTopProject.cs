updateTopProject
	Project current == Project topProject
	ifFalse:[^ self].

""
			World color: Preferences defaultWorldColor.
			World submorphs
				select: [:each | ""
					(each isKindOf: StringMorph)
						and: [each contents = 'Squeak']]
				thenDo: [:each | each
						color: (self dark: 1)].
