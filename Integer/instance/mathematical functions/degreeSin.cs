degreeSin
	"Return the sine of self as an angle in degrees"
	self < 0 ifTrue: [^ 0.0 - (0 - self) degreeSin].
	self > 360 ifTrue: [^ (self \\ 360) degreeSin].
	self > 180 ifTrue: [^ 0.0 - (self - 180) degreeSin].
	self > 90 ifTrue: [^ (180 - self) degreeSin].
	" now 0<= self <= 90 "
	^ SinArray at: self+1