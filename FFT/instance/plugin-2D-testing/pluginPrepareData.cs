pluginPrepareData
	"The FFT plugin requires data to be represented in WordArrays or FloatArrays"
	sinTable _ sinTable asFloatArray.
	permTable _ permTable asWordArray.
	realData _ realData asFloatArray.
	imagData _ imagData asFloatArray.