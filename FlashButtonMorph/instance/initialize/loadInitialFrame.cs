loadInitialFrame
	"Resort our children"
	super loadInitialFrame.
	submorphs _ submorphs sortBy:[:m1 :m2| m1 depth > m2 depth].
	self lookEnable: #(defaultLook) disable:#(sensitive overLook pressLook)