declareCVarsIn: cg
	cg var: #litVertex type: #'float*'.
	cg var: #primLight type: #'float*'.
	cg var: #primMaterial type: #'float*'.
	cg var: #l2vDirection declareC: 'double l2vDirection[3]'.
	cg var: #l2vSpecDir declareC: 'double l2vSpecDir[3]'.
	cg var: #vtxInColor declareC: 'double vtxInColor[4]'.
	cg var: #vtxOutColor declareC: 'double vtxOutColor[4]'.
	cg var: #l2vDistance type: #'double'.
	cg var: #lightScale type: #'double'