isProbablyPrimeWithK: k andQ: q 
	"Algorithm P, probabilistic primality test, from
	Knuth, Donald E. 'The Art of Computer Programming', Vol 2,
	Third Edition, section 4.5.4, page 395, P1-P5 refer to Knuth description."

	"P1"

	| x j y |
	x := (self - 2) atRandom + 1.
	"P2"
	j := 0.
	y := x raisedToInteger: q modulo: self.
	"P3"
	
	[(((j = 0) & (y = 1)) | (y = (self - 1))) ifTrue: [^true].
	((j > 0) & (y = 1)) ifTrue: [^false].	"P5"
	true]  
			whileTrue: 
				[j := j + 1.
				(j < k) ifTrue: [y := y squared \\ self]
				ifFalse:[^ false]]