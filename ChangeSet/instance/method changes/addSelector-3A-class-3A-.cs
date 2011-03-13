addSelector: selector class: class 
	"Include indication that a method has been added.
	 5/16/96 sw: tell Utilities of the change so it can put up an in-order browser on recent submissions."

	Utilities noteMethodSubmission: selector forClass: class name.
	self atSelector: selector class: class put: #add