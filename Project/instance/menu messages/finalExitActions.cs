finalExitActions

	| navigator |

	world isMorph ifTrue: [
		navigator _ world findA: ProjectNavigationMorph.
		navigator ifNotNil: [navigator retractIfAppropriate].
	].
