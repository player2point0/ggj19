export class SimpleScene extends Phaser.Scene {
    create() {
      this.add.text(100, 100, 'Hello Phaser!', { fill: '#0f0' });
      const player = this.add.rectangle(0,0,50,50,'0xff0000')
      console.log(player)
    }
}