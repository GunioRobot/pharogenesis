finalEnterActions
	| navigator armsLengthCmd navType |

	navType _ ProjectNavigationMorph preferredNavigator.
	armsLengthCmd _ self parameterAt: #armsLengthCmd ifAbsent: [nil].
	navigator _ world findA: navType.
	Preferences showProjectNavigator & navigator isNil ifTrue: [
		(navigator _ navType new)
			bottomLeft: world bottomLeft;
			openInWorld: world.
	].
	navigator notNil & armsLengthCmd notNil ifTrue: [
		navigator color: Color lightBlue
	].
	armsLengthCmd notNil ifTrue: [
		Preferences showFlapsWhenPublishing
			ifFalse:[self flapsSuppressed: true.
					navigator ifNotNil:[navigator visible: false]].
		armsLengthCmd openInWorld: world
	].