initializeFlapsQuads
	"initialize the list of dynamic flaps quads.
	self initializeFlapsQuads"
	FlapsQuads _ nil. 
	self registeredFlapsQuads at: 'PlugIn Supplies' put: self defaultsQuadsDefiningPlugInSuppliesFlap;
		 at: 'Stack Tools' put: self defaultsQuadsDefiningStackToolsFlap;
		 at: 'Supplies' put: self defaultsQuadsDefiningSuppliesFlap;
		 at: 'Tools' put: self defaultsQuadsDefiningToolsFlap;
		 at: 'Widgets' put: self defaultsQuadsDefiningWidgetsFlap;
		 at: 'Scripting' put: self defaultsQuadsDefiningScriptingFlap.
	^ self registeredFlapsQuads