initializeFrom: aTexture
	"Private. Initialize the receiver from aTexture.
	Note: width/height/depth are not set here since textures
	are subject to restricted allocation and need to be handled
	specially."
	wrap _ aTexture wrap.
	envMode _ aTexture envMode.
	interpolate _ aTexture interpolate.