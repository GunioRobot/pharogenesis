declareCVarsIn: cg
	cg addHeaderFile:'"b3d.h"'.
	cg var: #viewport type: #'B3DPrimitiveViewport'.
	cg var: #state type: #'B3DRasterizerState'