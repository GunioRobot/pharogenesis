ifTests

	true ifTrue: [
		self print: 'true case'
	].

	true ifFalse: [
		self print: 'false case'
	].

	true ifTrue: [
		self print: 'true case'
	] ifFalse: [
		self print: 'false case'
	].

	true ifFalse: [
		self print: 'false case'
	] ifTrue: [
		self print: 'true case'
	].