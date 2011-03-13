rebuild

	| myServer |

	self removeAllMorphs.
	self updateCurrentStatusString.
	self addARow: {
		self inAColumn: {
			SimpleButtonMorph new target: self; actionSelector: #delete; label: 'X'.
		}.
		self inAColumn: {
			UpdatingStringMorph new
				useStringFormat;
				target:  self;
				getSelector: #currentStatusString;
				contents: self currentStatusString;
				stepTime: 2000;
				lock.
		}.
		self inAColumn: {
			SimpleButtonMorph new target: self; actionSelector: #toggleFull; label: 'O'.
		}.
	}.
	myServer _ self server.
	(myServer isNil or: [fullDisplay not]) ifTrue: [
		^World startSteppingSubmorphsOf: self
	].
	self addARow: {
		self inAColumn: {
			(StringMorph contents: '--clients--') lock.
		}.
	}.

	myServer clients do: [ :each |
		self addARow: {
			UpdatingStringMorph new
				useStringFormat;
				target: each;
				getSelector: #currentStatusString;
				contents: each currentStatusString;
				stepTime: 2000;
				lock.
		}
	].
	World startSteppingSubmorphsOf: self.