standardLeftFlap
	| aFlap aFlapTab aButton aClock buttonColor anOffset |

	aFlap _ PasteUpMorph newSticky borderWidth: 0.
	aFlapTab _ FlapTab new referent: aFlap.
	aFlapTab assumeString: 'Squeak' font: Preferences standardFlapFont orientation: #vertical color: Color brown lighter lighter.
	aFlapTab edgeToAdhereTo: #left; inboard: false.
	aFlapTab setToPopOutOnDragOver: true.
	aFlapTab setToPopOutOnMouseOver: true.

	aFlapTab position: (0 @ ((Display height - aFlapTab height) // 2)).
	aFlap setProperty: #flap toValue: true.
	aFlap color: (Color brown muchLighter lighter "alpha: 0.3").
	aFlap extent: 200 @ self currentWorld height.

	self addProjectNavigationButtonsTo: aFlap.
	anOffset _ 16.

	buttonColor _ Color green muchLighter.
	aButton _ SimpleButtonMorph new target: Smalltalk.
	aButton color: buttonColor.
	aButton actionSelector: #saveSession.
	aButton setBalloonText: 'Make a complete snapshot of the current state of the image onto disk.'.
	aButton label: 'snapshot'.
	aFlap addCenteredAtBottom: aButton offset: anOffset.

	aButton _ aButton fullCopy target: Utilities.
	aButton actionSelector: #fileOutChanges.
	aButton label: 'file out changes'.
	aButton setBalloonText: 'File out the current change set to disk.'.
	aFlap addMorph: aButton.
	aFlap addCenteredAtBottom: aButton offset: anOffset.

	aButton _ aButton fullCopy target: Utilities.
	aButton actionSelector: #browseRecentSubmissions.
	aButton setBalloonText: 'Open a message-list browser showing the 20 most-recently-submitted methods.'.
	aButton label: 'recent submissions'.
	aFlap addCenteredAtBottom: aButton offset: anOffset.

	aClock _ ClockMorph newSticky.
	aClock color: Color red.
	aClock showSeconds: false.
	aClock font: (TextStyle default fontAt: 3).
	aClock step.
	aClock setBalloonText: 'The time of day.  If you prefer to see seconds, check out my menu.'.
	aFlap addCenteredAtBottom: aClock offset: anOffset.

	aButton _ aButton fullCopy target: Preferences.
	aButton actionSelector: #openPreferencesInspector.
	aButton setBalloonText: 'Open a window allowing me to view and change various Preferences.'.
	aButton label: 'preferences...'.
	aButton color: Color cyan muchLighter.
	aFlap addCenteredAtBottom: aButton offset: anOffset.

	aButton _ aButton fullCopy target: Utilities.
	aButton actionSelector: #updateFromServer.
	aButton label: 'load code updates'.
	aButton setBalloonText: 'Check the Squeak server for any new code updates, and load any that are found.'.
	aFlap addCenteredAtBottom: aButton offset: anOffset.

	self addSystemStatusLinesTo: aFlap.

	aButton _ SimpleButtonMorph new target: self.
	aButton actionSelector: #explainFlaps; color: buttonColor.
	aButton label: 'About flaps...'.
	aButton setBalloonText: 'Click here to get a window of information about flaps.'.
	aFlap addCenteredAtBottom: aButton offset: anOffset.

	aButton _ aButton fullCopy target: Preferences; actionSelector: #editAnnotations;
		label: 'Annotations...'.
	aButton setBalloonText: 'Click here to get a little window that will allow you to specify which types of annotations, in which order, you wish to see in the annotation pane of method-list browsers.'.
	aFlap addCenteredAtBottom: aButton offset: anOffset.

	aButton _ TrashCanMorph newSticky.
	aFlap addCenteredAtBottom: aButton offset: anOffset.
	aButton startStepping.

	^ aFlapTab