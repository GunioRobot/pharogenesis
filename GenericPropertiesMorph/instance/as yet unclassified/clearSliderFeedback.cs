clearSliderFeedback

	| feedBack |

	feedBack _ self valueOfProperty: #sliderFeedback ifAbsent: [^self].
	feedBack delete