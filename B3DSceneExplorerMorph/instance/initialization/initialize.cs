initialize
	| ctrl |
	super initialize.
	self extent: 300@300.
	self borderRaised.
	color := Color gray: 0.8.
	frameWidth := 25.

	b3DSceneMorph := AdvancedB3DSceneMorph new.
	self addMorphFront: b3DSceneMorph.
	
	wheels := Dictionary new.
	ctrl := WheelMorph new.
	ctrl target: b3DSceneMorph.
	ctrl actionSelector: #addFovAngle:.
	ctrl factor: -0.07.
	ctrl setBalloonText: 'FOV'.
	self addMorphFront: ctrl.
	wheels at: #fov put: ctrl.

	ctrl := WheelMorph new.
	ctrl target: b3DSceneMorph.
	ctrl actionSelector: #addDolly:.
	ctrl factor: 0.005.
	ctrl beVertical.
	ctrl setBalloonText: 'Dolly'.
	self addMorphFront: ctrl.
	wheels at: #dolly put: ctrl.

	ctrl := WheelMorph new.
	ctrl target: b3DSceneMorph.
	ctrl actionSelector: #rotateZ:.
	ctrl beVertical.
	ctrl setBalloonText: 'z Axis'.
	self addMorphFront: ctrl.
	wheels at: #rotZ put: ctrl.

	ctrl := WheelMorph new.
	ctrl target: b3DSceneMorph.
	ctrl actionSelector: #rotateY:.
	ctrl setBalloonText: 'y Axis'.
	self addMorphFront: ctrl.
	wheels at: #rotY put: ctrl.

	ctrl := WheelMorph new.
	ctrl target: b3DSceneMorph.
	ctrl actionSelector: #rotateX:.
	ctrl beVertical.
	ctrl setBalloonText: 'x Axis'.
	self addMorphFront: ctrl.
	wheels at: #rotX put: ctrl.