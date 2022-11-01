export class SensorConfig {

    constructor(position: number, name: string, unit: string, description: string, image: string) {
        this.position = position;
        this.name = name;
        this.unit = unit;
        this.description = description;
        this.image = image;
    }

    position: number;
    name: string;
    unit: string;
    description: string;
    image: string;
}