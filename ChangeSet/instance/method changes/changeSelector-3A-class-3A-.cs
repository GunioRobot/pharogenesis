changeSelector: selector class: class 
	"Include indication that a method has been edited. 
	 5/16/96 sw: tell Utilities of the change so it can put up an in-order browser on recent submissions."

	Utilities noteMethodSubmission: selector forClass: class name.
	(self atSelector: selector class: class) = #add 
		ifFalse: [self atSelector: selector class: class put: #change]
			"Don't forget a method is new just because it's been changed"