checkForRebuild
	| lastScreenMode flapsSuppressed |

	lastScreenMode _ ScreenController lastScreenModeSelected ifNil: [false].
	flapsSuppressed _ CurrentProjectRefactoring currentFlapsSuppressed.
	((self valueOfProperty: #currentNavigatorVersion) = self currentNavigatorVersion
			and: [lastScreenMode = self inFullScreenMode
			and: [flapsSuppressed = self inFlapsSuppressedMode
			and: [(self valueOfProperty: #includeSoundControlInNavigator) = 
						Preferences includeSoundControlInNavigator]]]) ifFalse: [
		self 
			setProperty: #includeSoundControlInNavigator 
			toValue: Preferences includeSoundControlInNavigator.
		self setProperty: #flapsSuppressedMode toValue: flapsSuppressed.
		self setProperty: #showingFullScreenMode toValue: lastScreenMode.
		self setProperty: #currentNavigatorVersion toValue: self currentNavigatorVersion.
		self removeAllMorphs.
		self addButtons.
	].
