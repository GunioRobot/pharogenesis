fontOfPointSize: size
	^ (TextConstants at: #ComicBold ifAbsent: [TextStyle default]) fontOfPointSize: size