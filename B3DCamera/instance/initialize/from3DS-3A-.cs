from3DS: aDictionary
	"Initialize the receiver from a 3DS camera.
	Note: #near and #far are NOT clipping planes in 3DS!"
	self position: (aDictionary at: #position).
	self target: (aDictionary at: #target).
	self up: (0@1@0).
	self flag: #TODO. "Include #roll value for upDirection"
	self fieldOfView: 2400.0 / (aDictionary at: #focal).