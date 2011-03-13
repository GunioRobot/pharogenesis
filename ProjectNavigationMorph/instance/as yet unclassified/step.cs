step
	| wb lastScreenMode flapsSuppressed |

	owner ifNil: [^ self].
	(self ownerThatIsA: HandMorph) ifNotNil: [^self].
	lastScreenMode _ ScreenController lastScreenModeSelected ifNil: [false].
	flapsSuppressed _ CurrentProjectRefactoring currentFlapsSuppressed.
	((self valueOfProperty: #currentNavigatorVersion) = self currentNavigatorVersion
			and: [lastScreenMode = self inFullScreenMode
			and: [flapsSuppressed = self inFlapsSuppressedMode]]) ifFalse: [
		self setProperty: #flapsSuppressedMode toValue: flapsSuppressed.
		self setProperty: #showingFullScreenMode toValue: lastScreenMode.
		self setProperty: #currentNavigatorVersion toValue: self currentNavigatorVersion.
		self removeAllMorphs.
		self addButtons.
	].
	owner == self world ifTrue: [
		owner addMorphInLayer: self.
		wb _ self worldBounds.
		self left < wb left ifTrue: [self left: wb left].
		self right > wb right ifTrue: [self right: wb right].
		self positionVertically.
	].