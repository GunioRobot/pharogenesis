testAllRegisteredServices
	"(self selector: #testAllRegisteredServices) debug"

	self shouldnt: [FileList allRegisteredServices] raise: Error