fixOldVersion

	| uName uForm uEmail uIP |
	uName _ self userName.
	uForm _ userPicture ifNil: [
		(self 
		findDeepSubmorphThat: [ :x | (x isKindOf: ImageMorph) or: [x isSketchMorph]] 
		ifAbsent: [self halt]) form.
	].
	uEmail _ (fields at: #emailAddress) contents.
	uIP _ self ipAddress.
	self
		userName: uName 
		userPicture: (uForm scaledToSize: 61@53)
		userEmail: uEmail 
		userIPAddress: uIP
