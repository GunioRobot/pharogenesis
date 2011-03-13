drawSubmorphsOn: aCanvas
	| myCanvas |
	aCanvas clipBy: self bounds during:[:tempCanvas|
		myCanvas := tempCanvas asBalloonCanvas.
		myCanvas aaLevel: (self defaultAALevel ifNil:[1]).
		myCanvas deferred: self deferred.
		myCanvas transformBy: self transform during:[:childCanvas| 
			activeMorphs reverseDo:[:m| childCanvas fullDrawMorph: m]].
		myCanvas flush].
