drawOn: aCanvas
	| pHour pMin pSec time |
	time _ Time now.
	pHour _ self radius: 0.6 hourAngle: time hours + (time minutes/60.0).
	pMin _ self radius: 0.72 hourAngle: (time minutes / 5.0).
	pSec _ self radius: 0.8 hourAngle: (time seconds / 5.0).

	antialias ifTrue: [
		aCanvas asBalloonCanvas
			aaLevel: 4;
			drawOval: (bounds insetBy: borderWidth // 2 + 1) color: self fillStyle
				borderWidth: borderWidth borderColor: borderColor;
			drawOval: (bounds insetBy: self extent*0.35) color: cColor
				borderWidth: 0 borderColor: Color black;
			drawPolygon: {self center. pHour}
				color: Color transparent borderWidth: 3 borderColor: handsColor;
			drawPolygon: {self center. pMin}
				color: Color transparent borderWidth: 2 borderColor: handsColor;
			drawPolygon: {self center. pSec}
				color: Color transparent borderWidth: 1 borderColor: handsColor]
		ifFalse: [
			super drawOn: aCanvas.
			aCanvas
				fillOval: (bounds insetBy: self extent*0.35) color: cColor;
				line: self center to: pHour width: 3 color: handsColor;
				line: self center to: pMin width: 2 color: handsColor;
				line: self center to: pSec width: 1 color: handsColor.]
