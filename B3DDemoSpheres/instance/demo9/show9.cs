show9

    " B3DDemoSpheres new show9"

     | view |

  self createScene9.
  (view := B3DTutorialScenePresenterMorph new)
     source: self description: #descriptionScene9;
     scene: scene.
  view clearColor: (Color gray: 0.5).
  view rotateX: 25.4.
  view beRotating; openInSystemWindow.