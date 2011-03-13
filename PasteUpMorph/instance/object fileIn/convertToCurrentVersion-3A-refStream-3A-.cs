convertToCurrentVersion: varDict refStream: smartRefStrm
	
	"transition from project to worldState (8/16/1999)"
	worldState ifNil: [varDict at: 'project' ifPresent: [ :x | worldState _ x]].

	"elimination of specific gradient stuff (5/6/2000)"
	varDict at: 'fillColor2' ifPresent: [ :color2 |
		(color isColor and: [color2 isColor and: [color ~= color2]]) ifTrue: [
			self useGradientFill.
			self fillStyle
				colorRamp: {0.0 -> color. 1.0 -> color2};
				radial: false;
				origin: self position;
				direction: ((varDict at: 'gradientDirection') == #vertical 
					ifTrue:[0@self height] 
					ifFalse:[self width@0]).
		]
	].
	^super convertToCurrentVersion: varDict refStream: smartRefStrm.
