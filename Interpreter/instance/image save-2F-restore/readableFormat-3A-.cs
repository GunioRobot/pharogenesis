readableFormat: imageVersion
	"Anwer true if images of the given format are readable by this interpreter. Allows a virtual machine to accept selected older image formats."

	^ imageVersion = self imageFormatVersion
"
	Example of multiple formats:
	^ (imageVersion = self imageFormatVersion) or: [imageVersion = 6504]
"