querySourceSurface: handle
	"Query the dimension of an OS surface.
	This method is provided so that in case the inst vars of the
	source form are broken, *actual* values of the OS surface
	can be obtained. This might, for instance, happen if the user
	resizes the main window.
	Note: Moved to a separate function for better inlining of the caller."
	"^(self cCode:'ioGetSurfaceFormat(handle, &srcWidth, &srcHeight, &sourcePixSize, &srcFormat)')
		~~ 0"
	^false