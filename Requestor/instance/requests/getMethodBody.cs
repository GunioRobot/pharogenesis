getMethodBody
	^ UIManager default 
			multiLineRequest: 'Please enter the full body of the method you want to define' translated
			centerAt: 0@0 
			initialAnswer: '' 
			answerHeight: 300.
