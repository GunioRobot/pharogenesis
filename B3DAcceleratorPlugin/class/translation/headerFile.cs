headerFile
^'/* Header file for 3D accelerator plugin */

/* module initialization support */
int b3dxInitialize(void); /* return true on success, false on error */
int b3dxShutdown(void); /* return true on success, false on error */

/* Display support primitives */
int b3dxCreateDisplaySurface(int w, int h, int d); /* return handle or -1 on error */
int b3dxDestroyDisplaySurface(int handle); /* return true on success, false on error */
int b3dxDisplayColorMasks(int handle, int masks[4]); /* return true on success, false on error */
int b3dxSupportsDisplayDepth(int depth); /* return true or false */
int b3dxFlushDisplaySurface(int handle); /* return true on success, false on error */
int b3dxFinishDisplaySurface(int handle); /* return true on success, false on error */

/* optional accelerated blt primitives */
int b3dxFillDisplaySurface(int handle, int pv, int x, int y, int w, int h); /* return true on success, false on error */
int b3dxBltToDisplay(int displayHandle, int formHandle, int dstX, int dstY, int srcX, int srcY, int w, int h); /* return true on success, false on error */
int b3dxBltFromDisplay(int displayHandle, int formHandle, int dstX, int dstY, int srcX, int srcY, int w, int h); /* return true on success, false on error */

/* Texture support primitives */
int b3dxAllocateTexture(int w, int h, int d); /* return handle or -1 on error */
int b3dxDestroyTexture(int handle); /* return true on success, false on error */
int b3dxActualTextureDepth(int handle); /* return depth or <0 on error */
int b3dxActualTextureWidth(int handle); /* return width or <0 on error */
int b3dxActualTextureHeight(int handle); /* return height or <0 on error */
int b3dxTextureColorMasks(int handle, int masks[4]);  /* return true on success, false on error */

/* Form support primitives */
int b3dxAllocateForm(int w, int h, int d); /* return handle or -1 on error */
int b3dxDestroyForm(int handle); /* return true on success, false on error */
int b3dxFormColorMasks(int handle, int masks[4]);  /* return true on success, false on error */

/* Rasterizer support primitives */
int b3dxSetViewport(int x, int y, int w, int h); /* return true on success, false on error */
int b3dxClearDepthBuffer(void); /* return true on success, false on error */
int b3dxRasterizeVertexBuffer(int primType, int texHandle, float *vtxArray, int vtxSize, int *idxArray, int idxSize, int *bounds); /* return true on success, false on error */

'.