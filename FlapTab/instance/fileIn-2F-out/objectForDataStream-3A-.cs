objectForDataStream: refStrm
	| dp |
	"I am about to be written on an object file.  If I am a global flap, write a proxy instead."

	(Utilities globalFlapTabsIfAny includes: self) ifTrue: [
		dp _ DiskProxy global: #Utilities selector: #globalFlapTabOrDummy: 
					args: {self flapMenuTitle}.
		refStrm replace: self with: dp.
		^ dp].

	^ super objectForDataStream: refStrm