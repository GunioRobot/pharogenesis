isAvailable
	"Return true if this engine is available (e.g., all of its parts are avaiable)"
	^(self transformer isAvailable and:[
		self shader isAvailable and:[
			self clipper isAvailable and:[
				self rasterizer isAvailable]]])