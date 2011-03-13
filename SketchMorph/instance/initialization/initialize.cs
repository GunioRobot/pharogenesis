initialize
	"initialize the state of the receiver"
	super initialize.
	self initializeAllButForm.
	self initializeForm: self defaultForm