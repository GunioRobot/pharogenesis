renderOn: aRenderer
	defaultCamera ifNotNil:[
		defaultCamera setClippingPlanesFrom: self.
		defaultCamera aspectRatio: aRenderer viewport aspectRatio.
		defaultCamera renderOn: aRenderer].
	lights do:[:light| aRenderer addLight: light].
	objects do:[:obj| obj renderOn: aRenderer].