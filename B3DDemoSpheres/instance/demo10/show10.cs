show10

    " B3DDemoSpheres new show10"

     | view |

  self createScene10.
  (view := B3DTutorialScenePresenterMorph new)
     source: self description: #descriptionScene10;
     scene: scene.
  view clearColor: (Color gray: 0.5).
  view rotateX: 25.4.
  view beRotating; openInSystemWindow.