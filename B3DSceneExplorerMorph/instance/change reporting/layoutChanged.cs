layoutChanged
	| ctrl |
	super layoutChanged.

	b3DSceneMorph ifNil: [^self].
	b3DSceneMorph extent: (self extent - ((frameWidth * 2)@(frameWidth * 2))).
	b3DSceneMorph position: (self bounds origin + ((frameWidth)@(frameWidth))).

	wheels ifNil: [^self].
	wheels isEmpty ifTrue: [^self].

	ctrl := wheels at: #fov ifAbsent: [nil].
	ctrl ifNotNil: [
		ctrl position:
			self bounds corner -
				ctrl extent - 
				(frameWidth@((frameWidth - ctrl extent y) / 2) rounded)].

	ctrl := wheels at: #dolly ifAbsent: [nil].
	ctrl ifNotNil: [
		ctrl position:
			self bounds corner -
				ctrl extent - 
				((((frameWidth - ctrl extent x) / 2) rounded)@frameWidth)].

	ctrl := wheels at: #rotX ifAbsent: [nil].
	ctrl ifNotNil: [
		ctrl position:
			(self bounds origin x + (((frameWidth - ctrl extent x) / 2) rounded))@(self bounds corner y - ctrl extent y - frameWidth)].

	ctrl := wheels at: #rotY ifAbsent: [nil].
	ctrl ifNotNil: [
		ctrl position:
			(self bounds origin x + frameWidth)@(self bounds corner y - ctrl extent y - (((frameWidth - ctrl extent y) / 2) rounded))].

	ctrl := wheels at: #rotZ ifAbsent: [nil].
	ctrl ifNotNil: [
		ctrl position:
			self bounds origin +
			((((frameWidth - ctrl extent x) / 2) rounded)@frameWidth)].

	ctrl := wheels at: #accel ifAbsent:[nil].
	ctrl ifNotNil:[
		ctrl position:
			self bounds origin +
			(frameWidth @ ((((frameWidth - ctrl extent y) / 2) rounded)))].
