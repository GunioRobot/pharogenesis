bring: aController nextToTopFor: actionBlock
	"Allows transcript to display reasonably.  The transcript will
	appear on top during display.  Then by promoting it
	next to top, it will remain on top if at all possible - ie if it isnt
	under the active window.  If it is under the active window, it will
	still come to the top during display, and then drop back to second.
	Actually, it is promoted to top if necessary for the duration of the 
	action block so that things like label updating will work properly."
	| position value aPort aPortRect |
	position _ scheduledControllers indexOf: aController.
	position <= 1 ifTrue: [^ actionBlock value].
	self promote: aController.
	activeController == screenController ifFalse:
		[activeController view cacheBitsAsIs].
	aController controlInitialize.
	aPortRect _ aController view displayBox
					merge: aController view labelDisplayBox.
	value _ actionBlock value.
	aController controlTerminate.
	self promote: (scheduledControllers at: 2).
	activeController == screenController ifFalse:
		[aPort _ (BitBlt toForm: Display) clipRect: aPortRect.
		activeController view displayOn: aPort]