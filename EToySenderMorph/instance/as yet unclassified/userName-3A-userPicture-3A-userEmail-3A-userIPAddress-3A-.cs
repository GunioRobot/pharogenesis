userName: aString userPicture: aFormOrNil userEmail: emailString userIPAddress: ipString

	| dropZoneRow |

	self setProperty: #currentBadgeVersion toValue: self currentBadgeVersion.
	userPicture _ aFormOrNil ifNil: [
		(TextStyle default fontOfSize: 26) emphasized: 1; characterFormAt: $?
	].
	userPicture _ userPicture scaledToSize: 61@53.
	self killExistingChat.
	self removeAllMorphs.
	self useRoundedCorners.
	self 
		addARow: {
			self inAColumn: {(StringMorph contents: aString) lock}
		}.
	dropZoneRow _ self
		addARow: {
			self inAColumn: {userPicture asMorph lock}
		}.
	self establishDropZone: dropZoneRow.
	self
		addARow: {
			self textEntryFieldNamed: #emailAddress with: emailString
					help: 'Email address for this person'
		};
		addARow: {
			self textEntryFieldNamed: #ipAddress with: ipString
					help: 'IP address for this person'
		};
		addARow: {
			self indicatorFieldNamed: #working color: Color blue help: 'working'.
			self indicatorFieldNamed: #communicating color: Color green help: 'sending'.
			self buttonNamed: 'C' action: #startChat color: Color paleBlue 
								help: 'Open a written chat with this person'.
			self buttonNamed: 'T' action: #startTelemorphic color: Color paleYellow 
								help: 'Start telemorphic with this person'.
			self buttonNamed: '!' action: #tellAFriend color: Color paleGreen 
								help: 'Tell this person about the current project'.
			self buttonNamed: '?' action: #checkOnAFriend color: Color lightBrown 
								help: 'See if this person is available'.
			self buttonNamed: 'A' action: #startAudioChat color: Color yellow 
								help: 'Open an audio chat with this person'.
			self buttonNamed: 'S' action: #startNebraskaClient color: Color white 
								help: 'See this person''s world (if he allows that)'.
		}.
	