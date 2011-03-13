guessSqueakMapID
	| squeakmap map smpackage |
	self acceptFields.
	squeakmap := Smalltalk at: #SMSqueakMap ifAbsent: [
		^self inform: 'SqueakMap not loaded, cannot guess'].
	map := squeakmap default.
	smpackage := map packages detect: [ :smp | smp name = self packageName ] ifNone: [
		^self inform: 'could not find a SqueakMap package named ', self packageName].
	self smidString: smpackage id asString
	